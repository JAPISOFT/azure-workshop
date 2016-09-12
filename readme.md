##Azure Workshop
Na této stránce je uveden průběh workshopu "Hoď to do cloudu" sestaveného pro Barcamp v Hradci Králové.

### Seznámení s projektem
Součástí tohoto repositáře je složka AzureWorkshop. Jedná se o webovou aplikaci, nad kterou bude demonstrováno použití různých Azure služeb. 

#### Popis DEMO aplikace
Ukázková aplikace stahuje s každým requestem aktuální kurzovní lístek ze stránek ČNB, který se v reálném čase parsuje a zobrazuje na UI v podobě tabulky. V rámci této aplikace je použit IoC kontejner, díky kterému je možné snadno změnit implementaci rozhraní. Dodatečné implementace umí
- získaná data ze stránek ČNB uložit do Azure Storage
- získaná data ze stránek ČNB uložit do relační databáze Azure SQL 

Každý účastník školení nalezne tuto aplikaci na připraveném virtuálním počítači ve složce c:\Workshop. Do této složky je možné přejít i přímo z plochy.

#### Aktualizace aplikace
Před zahájením práce je doporučeno stáhnout aktuální verzi aplikace z GitHub repositáře. Ve složce `c:\Workshop` se nachází soubor `get_latest.bat`. 
Spuštěním tohoto dávkového souboru se stáhne aktuální verze aplikace z GitHub repositáře.

### Otevření projektu
Projekt lze otevřít pomocí MS Visual Studio 2015 (standardně ve verzi Communit). Spuštění je možné poklepáním na soubor `AzureWorkshop.sln` ve složce aplikace nebo otevřením tohoto souboru z již spuštěné instance Visual Studio 2015. Odkaz na Visual Studio 2015 se nachází v taskbaru.

### Nastavení názvu týmu/vývojáře
Aby měl lektor rychlou představu o průběhu workshopu, odesílá aplikace s každou kompilací informace o postupu výuky. 

Zvolte si své jméno týmu nebo nickname a zapište jej do souboru `C:\Workshop\azure-workshop\AzureWorkshop\Web.config` do sekce `<AppSettings> / <TeamName>`

	<add key="TeamName" value="MujNickname" />
	
Název dále během workshopu neměňte.

Projekt je tímto ve své základní verzi připraven k práci. Visual Studio 2015 nevypínejte.

## Microsoft Azure
Ukázková aplikace bude v průběhu workshopu několikrát nasazována ve změněných podobách do prostředí Microsoft Azure. Pro registraci do prostředí Microsoft Azure postupujte dle pokynů lektora.

### Registrace do portálu
TBA

## DEMO: Vytvoření Azure App Service
1. Přihlaste se do [azure portálu](https://portal.azure.com)
2. V levém menu vyberte možnost **New**
3. Do vyhledávacího pole zadejte **app service**
4. Vyberte z vyhledaných výsledků možnost **App Service Plan**
5. Klikněte na tlačítko **Create**
6. Formulář vyplňte dle pokynů lektora a klikněte na tlačítko **Create**

Tímto je založen hostingový plán, v rámci kterého je možné vytvářet jednotlivé webové aplikace.

### Vytvořené nové webové aplikace
1. Přihlaste se do [azure portálu](https://portal.azure.com)
2. Z nabídky levého menu zvolte možnost **New**
3. Do vyhledávacího pole zadejte **web app**
4. Vyberte z vyhledaných výsledků možnost **Web App**
5. Klikněte na tlačítko **Create**
6. Formulář vyplňte dle pokynů lektora a klikněte na tlačítko **Create**

Tímto je založena služba, do které je možné nasadit webovou aplikaci.

### DEMO: Nasazení webové aplikace do služby Web App
1. Přesvědčte se, zda máte stále aktivní Visual Studio 2015 a otevřený projekt (viz. tutoriál výše)
2. Vyzkoušejte funkčnost projektu stisknutím `CTRL+F5`
3. Klikněte pravým tlačítkem myši na název projektu **AzureWorkshop** v Solution Exploreru a z kontectového menu zvolte možnost **Publish**
4. Vyberte možnost Microsoft Azure Web Apps
5. Přihlaste se svými údaji k Microsoft účtu
6. Vyberte jedinou Subscription a následně Web App vytvořenou v předchozí části tohoto tutoriálu
7. Pokračujte vyplněním průvodce dle pokynů lektora
8. Kliknutím na **Publish** proveďte nasazení aplikace do prostředí Azure Web App

Tímto je nasazena webová aplikace v prostředí Azure Web App
