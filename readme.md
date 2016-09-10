##Azure Workshop
Na této stránce naleznete postup práce v rámci Workshopu "Hod to do cloudu" pro Barcam Hradec Králové.

### Seznámení s projektem
Součástí tohoto repositáře je složka AzureWorkshop. Jedná se o webovou aplikaci, nad kterou bude demonstrováno použití Azure cloudu. Každý účastník školení nalezne tuto aplikaci na připraveném virtuálním počítači ve složce Worskhop. Do této složky se lze prokliknout přímo z plochy a kromě složky s weobou aplikací obsahuje dávkový soubor get_latest.bat. Spuštěním tohoto souboru se stáhne aktuální verze aplikace z tohoto repositáře.

### Otevření projektu
Projekt otevřete pomocí MS Visual Studio 2015. To lze přímo spuštěním souboru AzureWorkshop.sln ve složce aplikace nebo otevřením tohoto souboru z již spuštěné instance Visual Studio 2015. Odkaz na Visual Studio 2015 se nachází v taskbaru.

### Nastavení názvu týmu
Aby měl lektor rychlou představu o průběhu workshopu, odesílá systém informace o progresu výuky. Zvole si své jméno nebo nickname a zapište jej do souboru C:\Workshop\azure-workshop\AzureWorkshop\Web.config do sekce <AppSettings> / <TeamName>

	<add key="TeamName" value="MujNickname" />
	
Název již během workshopu neměňte.

Projekt je tímto ve své základní verzi připraven k práci.

## Microsoft Azure

### Registrace do portálu

### Seznámení s portálem

## DEMO: Vytvoření Azure App Service

## DEMO: Diagnostická služba Application Insights

## DEMO: Ukládání dat do Azure Storage

## DEMO: Připojení k relační databázi MS SQL