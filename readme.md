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
Před zahájením práce je doporučeno stáhnout aktuální verzi aplikace z GitHub repositáře. Ve složce c:\Workshop se nachází soubor `get_latest.bat`. 
Spuštěním tohoto dávkového souboru se stáhne aktuální verze aplikace z GitHub repositáře.

### Otevření projektu
Projekt lze otevřít pomocí MS Visual Studio 2015 (standardně ve verzi Communit). Spuštění je možné poklepáním na soubor `AzureWorkshop.sln` ve složce aplikace nebo otevřením tohoto souboru z již spuštěné instance Visual Studio 2015. Odkaz na Visual Studio 2015 se nachází v taskbaru.

### Nastavení názvu týmu/vývojáře
Aby měl lektor rychlou představu o průběhu workshopu, odesílá aplikace s každou kompilací informace o postupu výuky. 
Zvolte si své jméno týmu nebo nickname a zapište jej do souboru `C:\Workshop\azure-workshop\AzureWorkshop\Web.config` do sekce `<AppSettings> / <TeamName>`

	<add key="TeamName" value="MujNickname" />
	
Název již během workshopu neměňte.

Projekt je tímto ve své základní verzi připraven k práci.

## Microsoft Azure
Ukázková aplikace bude v průběhu workshopu několikrát nasazována ve změněných podobách do prostředí Microsoft Azure. Pro registraci do prostředí Microsoft Azure postupujte dle pokynů lektora.

### Registrace do portálu
TBA

### Seznámení s portálem
TBA

## DEMO: Vytvoření Azure App Service
TBA

## DEMO: Diagnostická služba Application Insights
TBA
## DEMO: Ukládání dat do Azure Storage
TBA

## DEMO: Připojení k relační databázi MS SQL
TBA