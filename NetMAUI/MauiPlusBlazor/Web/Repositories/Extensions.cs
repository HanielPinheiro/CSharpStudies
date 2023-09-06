using CurrieTechnologies.Razor.SweetAlert2;

namespace Web.Repositories
{
    public static class Extensions
    {
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
    }
}
