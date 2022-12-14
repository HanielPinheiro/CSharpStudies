using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Util
{
    public class CurrentAccountsList : IEnumerable
    {
        private CurrentAccount[] accounts = null;
        public int ListSize { get; private set; }
        public IEnumerator GetEnumerator()
        {
            foreach (object obj in accounts)
            {
                if (obj == null)
                {
                    break;
                }
                yield return obj;
            }
        }

        public CurrentAccountsList(int size = 5)
        {
            accounts = new CurrentAccount[size];
            ListSize = 0;
        }

        public CurrentAccount this[int index]
        {
            get
            {
                return GetAccountByIndex(index);
            }
        }

        public void Add(CurrentAccount account)
        {
            try
            {
                CheckCapacity(ListSize + 1);
                accounts.SetValue(account, ListSize);
                ListSize++;
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in Add item to array on method {nameof(Add)}. Error message: {ex.Message} .");
            }
        }

        private void CheckCapacity(int necessarySize)
        {
            try
            {
                if (accounts.Length >= necessarySize)
                {
                    return; // finaliza a execução do método
                }

                CurrentAccount[] newArray = new CurrentAccount[necessarySize];
                int size = accounts.Length;

                for (int i = 0; i < size; i++)
                    newArray[i] = accounts[i];

                accounts = newArray;
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in increase list capacity on method {nameof(CheckCapacity)}. Error message: {ex.Message} .");
            }
        }

        public void Remove(CurrentAccount account)
        {
            try
            {
                int accountIdx = -1;
                for (int i = 0; i < ListSize; i++)
                {
                    CurrentAccount actualAccount = accounts[i];
                    if (actualAccount == account)
                    {
                        accountIdx = i;
                        break;
                    }
                }

                //Desloca o vetor paa a esquerda [0] [1] [2] → [0] [2] [null]
                for (int i = accountIdx; i < accounts.Length - 1; i++)
                    accounts[i] = accounts[i + 1];

                ListSize--;
                accounts[ListSize] = null;
                CheckCapacity(ListSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail in increase list capacity on method {nameof(Remove)}. Error message: {ex.Message} .");
            }

        }

        public CurrentAccount HigherBalance()
        {
            CurrentAccount higherBalanceAccount = accounts[0];
            double higherBalance = accounts[0].SeeBalance(); ;

            for (int i = 1; i < ListSize; i++)
            {
                if (accounts[i].SeeBalance() > higherBalance)
                {
                    higherBalance = accounts[i].SeeBalance();
                    higherBalanceAccount = accounts[i];
                }
            }

            return higherBalanceAccount;
        }

        public override string ToString()
        {
            string superString = "";

            for (int i = 0; i < ListSize; i++)
                superString += $"Id: {i}\tHolder: {accounts[i].holder.Name}\tAccount: {accounts[i].account}\tAgencie: {accounts[i].agencie_number}\tBalance: {accounts[i].SeeBalance()} \n";

            return superString;
        }

        public CurrentAccount GetAccountByIndex(int index)
        {
            if (index < 0 || index > ListSize)
                throw new Exception("Index out of range");

            return accounts[index];
        }

        public int Count()
        {
            return accounts.Length;
        }

        
    }
}
