using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;

namespace Web.Repositories
{
    public static class Extensions
    {
        #region SweetAlertService
        public static async Task<bool> Ask(this SweetAlertService alert, string title, string text)
        {
            SweetAlertResult result = await alert.FireAsync(new SweetAlertOptions()
            {
                Title = title,
                Text = text,
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Yes"
            });

            if (string.IsNullOrEmpty(result.Value)) return false;
            return true;
        }
        #endregion

        #region IJSRuntime
        public static ValueTask<object> SetLocalStorage(this IJSRuntime js, string key, string content)
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, content);
        }

        public static ValueTask<object> GetLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.getItem", key);
        }

        public static ValueTask<object> RemoveLocalStorage(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }
        #endregion
    }
}
