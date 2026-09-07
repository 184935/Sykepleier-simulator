# Oblig 4 i DAT154

Problemstilling: Lage et system bestående av 3 applikasjon som kommuniserer sammen, for bruk i opplæring av sykepleierstudenter. 
Ønsket var å få en web-basert applikasjon hvor en kunne få en liste over forskjellige test scenarioer, samt på sikt lage egne. 
Videre skulle det lages en desktop-applikasjon for å kjøre simuleringen, den skulle kommunisere med web-applikasjonen for å finne valgt case. 
All aktivitet i simuleringen skulle loggføres, og videreformidles til en tredje desktop-applikasjon hvor en sensor/lærer kunne se hva som ble gjort, og gjøre seg notater om det som ble gjort. Alt dette skulle gjøres i tre forskjellige .NET rammeverk. 

Vi valgte å bruke et REST-API i backend, som hadde ansvar for å utføre CRUD-operasjoner på databasen, og var endepunktet som de tre applikasjonene kommuniserte med. For tilnærmet "real-time" informasjon til sensor, ble det implementert polling av events hvert 3. sekund. Alle handlinger i simuleringen ble loggført som en event, med tidsstempel, og en beskrivelse av handlingen. Kommentarer av foreleser ble også tidsstemplet, her gjorde vi valget om å tidsstemple fra øyeblikket foreleser trykket på "kommenter". Dette for å få mer nøyaktig oversikt over når i handlingsrekken de oppdaget noe. 
