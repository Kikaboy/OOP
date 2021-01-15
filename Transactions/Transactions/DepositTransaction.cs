using System;
using Bank;

namespace Transactions
{
    public class DepositTransaction : Transaction
    {
        InterfaceUI ui;
        Account account;

        public DepositTransaction(InterfaceUI ui, Account account)
        {
            this.ui = ui;
            this.account = account;
        }
        public override void Execute()
        {
            account.Funds += ui.RequestDepositAmount();
        }
    }
}
