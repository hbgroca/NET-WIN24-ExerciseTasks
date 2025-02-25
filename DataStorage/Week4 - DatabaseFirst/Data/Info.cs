using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Info
    {
        /*
         Övningsuppgift: Database First

            Uppgift
            Du ska i denna övningsuppgift använda dig av din redan befintliga databas som du har skapat, med tabeller i, från inlämningsuppgiften. Du ska därefter skapa ett nytt projekt som du sedan ska hämta in dessa tabeller till ett projekt. Du kommer inte behöva göra något mer med själva projektet. Detta är bara en övning på att hämta in befintliga tabeller med hjälp av Database-First-modellen.


            Del 1: Befintlig databas
            Se till att du har en databas, denna databas ska ha tabeller i sig. Du kan använda dig av din databas som du skapat genom inlämningsuppgiften (tabellerna kommer inte påverkas). Du gör detta genom att du letar rätt på din connectionstring till din befintliga databas och spar den för den kommer du behöva ha i nästa steg.

            Om du av någon anledning inte har en databas, eller att du fortfarande inte har påbörjat din inlämningsuppgift, så är det högt tid att göra det. Men då får du skapa en ny egen databas och skapa tabeller och kolumner manuellt med hjälp av SQL.


            Del 2: Skapa en ny Solution med ett nytt Projekt
            I denna del så ska du skapa en helt ny solution i Visual Studio. Du ska alltså inte skapa ett nytt projekt i din inlämningsuppgift utan du ska skapa en helt ny solution och sedan skapar du ett klassbibliotek som du kan döpa till Data.


            Del 3: Installera nödvändiga NuGet-paket
            I denna del ska du installera de NuGet-paket som krävs för att kunna köra Database-First.

            Microsoft.EntityFrameworkCore.SqlServer
            Microsoft.EntityFrameworkCore.Tools
            Microsoft.EntityFrameworkCore.Design


            Del 4: Scaffolding
            Det har nu blivit dags att göra din scaffolding så att du kan få in dina tabeller som entiteter. Detta gör du med hjälp av kommandot Scaffold-DbContext.

            Scaffold-DbContext "din_connectionstring" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Contexts -Context DataContext -OutputDir Entities


            Del 6: Kontrollera
            Kontrollera så att du har fått in rätt entiteter i ditt projekt. 
         */

    }
}
