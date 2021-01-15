using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface InterfaceUI
    {
        double RequestDepositAmount();
        double RequestWithdrawalAmount();
        double RequestTransferAmount();
        void InformInsufficientFunds();
        void GiveOutCash(double amount);
    }
}
