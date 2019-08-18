# Virtual-Piano
### Проектна задача по предметот Визуелно Програмирање
Членови на тимот:
* **Аргетим Рамадани** 161553
* **Агрон Селими** 165042
***
Ова апликација е слична поедноставна имплементација на апликацијата за piano tutorials, **Synthesia**! И е комбинирано по сличен функционалност на играта **Piano Tiles**!

* **Synthesia** -> https://www.youtube.com/watch?v=R1cuoP25DGg
* **Piano Tiles** -> https://www.youtube.com/watch?v=kVIWzN0DmTc

За играње/свирење на пианото се користат копчиња од тастатура кои се означени на секое копче од пианото!

Поентава на играва е да се погодат сите ноти на точното време за да се добиват поени(**HITS**) во спротивно се добиват **MISSES**!  
_*Точното време значи кога нотава ке стигне на горниот дел од пианото тогаш да се притисне потребното копче со простор на грешка од 27 милисекунди!_

Стартното мени/форма на ова апликација:
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/Form_StartMenu.PNG "Start Menu Form")

При стартување на апликацијава се провере дали локацијата на потребните датотеки за музичките ноти е чувана порано, ако ја нема потребната локација тогаш копчињата **PLAY GAME** и **FREE PLAY** се оневозможени!
***
За да се овозможи клик на тие 2 копчиња мора прво да се локацираат потребните датотеки со клик на копчето **LOCATE NOTES FOLDER** при што се отвара диалог за одберење на фолдер кои ги има потребните музички датотеки:
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/LocateFolderDialog.PNG "Locate Notes Folder Dialog")
***
Ако се одбере фолдер кој што е празен или кај што неможат да се најдат сите потребни музички ноти, тогаш се отвара `MessageBox` кој кажува дека не се најдени потребните датотеки и прашува дали сакаме да си пробаме одново да си одбереме локација/фолдер:
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/Files%20not%20found%20error%20message.PNG "Notes not found!")
***
Кога ќе се одбере точна локација и ке се најдат сите потребни датотеки се прикажува друг MessageBox кој што прашува дали сакаме ова локација да си го чуваме за друг пат при стартување на апликацијата:
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/Remember%20Notes%20Dialog.PNG "Remember notes?!")
***
После овој `MessageBox` друг `MessageBox` не известува дека сите потребни датотеки се пронајдени и е време да се свири музика!
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/Notes%20loaded%20successfully.PNG "All ready!")

На овој момент **PLAY GAME** и **FREE PLAY** копчињата станаат овозможени за клик!
***
Играта има 2 опци:
1. **PLAY GAME**
2. **FREE PLAY**

1. **PLAY GAME**
При клик на **PLAY GAME** се отвара друга форма која содржи најгоре **Misses**, **Hits** и времето на музикава, под тие е главниот панел каде што се прикажуваат и идат надолу нотиве од музикава, и под главниот панел се наоѓа пианото со означените букви од тастатурава со кои може да се свири!
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/PlayGame_startno.PNG "Play Game!")
***
-Прво треба да се одбере MIDI(Мusical instrument digital interface, **.mid**) датотека со клик на **OPEN MIDI** при што ќе се отвара диалог кој овозможува и ограничува за одберење само на датотеки од тип (**.mid**)
***MIDI** датотекава од една снимана песна ги содржи сите ноти од таа песна заедно со време, брзина и многу други податоци за секоја нота!
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/open%20midi%20dialog.PNG "Open MIDI File Dialog!")
***
-По успешно отварање на миди датотека името на избраната датотека се пишува на копчето **OPEN MIDI** и останува видлива друго копче **START** која што овозможува стартуање на песната/играта!
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/midi%20opened%20stage.PNG "MIDI Opened!")
***
-На овој момент све е спремно за почнување на играта со клик на копчето **START** и штом почнува играта почнуваат и музичките ноти да станаат видливи на тој ред како што се снимани на **.mid** датотеката
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/notes%20going%20down.PNG "Game started!")
***
-Ако ги погодиме нотиве на време тогаш добиваме **HITS** и позадинава станува во зелена боја
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/hits.PNG "HITS")
***
-Ако не ги погодиме нотиве на време тогаш добиваме **MISSES** и позадинава станува во црвена боја
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/misses.PNG "MISSES")
***
-При крај на песната апликацијата се враќа пак на **PLAY GAME** од каде што можеме да смениме миди песна или да почнуваме пак играта со истава песна! Исто може да се вратиме назад кон главното мени со клик на копчето **<< BACK**
***
2. **FREE PLAY**
Со клик на ова копче се отвара друга форма слична со **PLAY GAME** форма, но тука имаме можност само да свириме на пианото слободно без играње
![alt text](https://github.com/ArgDevIO/Virtual-Piano/blob/master/VirtualPianoApp/Screenshots/FreePlay.PNG "FREE PLAY")   