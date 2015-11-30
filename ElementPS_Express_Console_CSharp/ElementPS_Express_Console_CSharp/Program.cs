using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPS_Express_Console_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var elementExpress = new ElementExpressService.ExpressSoapClient();
            var credentials = new ElementExpressService.Credentials();
            var application = new ElementExpressService.Application();
            var terminal = new ElementExpressService.Terminal();
            var card = new ElementExpressService.Card();
            var transaction = new ElementExpressService.Transaction();
            var address = new ElementExpressService.Address();

            credentials.AccountID = "";
            credentials.AccountToken = "";
            credentials.AcceptorID = "";

            application.ApplicationID = "";
            application.ApplicationVersion = "2.0";
            application.ApplicationName = "Dano Test";

            terminal.TerminalID = "01";
            terminal.CardholderPresentCode = ElementExpressService.CardholderPresentCode.NotPresent;
            terminal.CardInputCode = ElementExpressService.CardInputCode.ManualKeyed;
            terminal.TerminalCapabilityCode = ElementExpressService.TerminalCapabilityCode.KeyEntered;
            terminal.TerminalEnvironmentCode = ElementExpressService.TerminalEnvironmentCode.LocalAttended;
            terminal.CardPresentCode = ElementExpressService.CardPresentCode.NotPresent;
            terminal.MotoECICode = ElementExpressService.MotoECICode.NotUsed;
            terminal.CVVPresenceCode = ElementExpressService.CVVPresenceCode.NotProvided;

            transaction.TransactionAmount = "5.54";
            transaction.MarketCode = ElementExpressService.MarketCode.Retail;

            card.CardNumber = "5499990123456781";
            card.ExpirationMonth = "12";
            card.ExpirationYear = "19";

            Console.WriteLine("Sending credit card sale for 5.54");
            Console.WriteLine("");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var response = elementExpress.CreditCardSale(credentials, application, terminal, card, transaction, address, null);
            sw.Stop();

            Console.WriteLine("Response from Express: {0}  Elapsed Time: {1}", response.ExpressResponseMessage, sw.Elapsed.Seconds);
            Console.WriteLine("");

            Console.ReadLine();
            
        }
    }
}
