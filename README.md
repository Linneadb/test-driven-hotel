In the README the User story/ies should be outlined

User Story

As a hotel customer I would like to be able to browse available rooms and book a room that meet my criteria.

Acceptance criteria 

On a webpage, the hotel customer should be able to:

•	Find available rooms that match client criteria:

  o	select rooms with a view or a balcony - filterFeatures(),
  
  o	select rooms appropriate for the numbers of guests – filterGuests(),
  
  o	select dates for arrival and departure - filterDates(),
  
  o	see a list of rooms available – getAvailableRooms(Rooms),
  
•	see the total price of the booking – calculatePrice(),

•	book a room - createBooking().


Reflektion och utvärdering 

Skriv en kort reflektion om projektet. Beskriv vad du lärde dig, vilka utmaningar du stötte på, och hur du övervann dem. Om du gjorde om projektet när det var klart, vad hade du gjort annorlunda då? 

I arbetet med projektet har jag lärt mig mer om .NET programmering, applikationsstruktur med lager och, framför allt, tester och testdriven utveckling (TDD). Det har varit hjälpsamt att ha en metod för att ta sig en ett projekt. Ofta är det svårt att veta var man ska börja och det blir mycket hoppande fram och tillbaka. Med TDD fanns ett givet angreppssätt, något att hålla i handen under arbetets gång.

Det som var mest utmanande för mig när det gällde projektet var att min kunskap inom högnivåarkitektur och affärslogik inte är tillräckligt god för att ha en tydlig bild av projektets alla rörliga delar. Därmed kom inte det testdrivna arbetssättet alltid till sin rätt. När jag ständigt behövde justera logiken innebar det i sin tur ett oändligt antal omskrivningar av testerna, vilket ledde till stress och tidsbrist, vilket i sin tur ledde till att jag fick scoopa ut delar av min ursprungliga arkitektur/logik, vilket ledde till att jag fick skriva om testerna osv.

Det testdrivna arbetet satte sig först när jag nästan var klar med projektet. Hade jag gjort om projektet från start så hade jag inte gjort så mycket annorlunda. Kanske struntat i att lägga till en databas och haft en statisk lista direkt. Jag tror tyvärr att det varit lika mycket trial and error när det gäller logik och struktur om jag hade startat om idag. Det krävs helt enkelt mer träning och erfarenhet för att kunna planera för alla steg i förväg, och därmed kunna utnyttja styrkan in testdriven utveckling till fullo.

