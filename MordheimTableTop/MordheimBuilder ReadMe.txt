﻿TODO LIST
* Maximize the number of equipped  weapons (2 CC 2Ms see page 47) DONE,
	=> show user max is reached, 
* Save does not override the saved file. 
* Set filename on load, so save overwrite the previous version
* Improve the Special rules view
* Miscellaneous Equipment
* Solve event handler, selecting new warband, remove previous subscription
* Psychology
* Leader special rule to all captains (See sisters of sigmar)??
		Testing modifiers??? E.g. Leader within range, Reikland ld range bonus
* Add all magic rules, set lists to all wizards
* Proper MVVM
* Test Comment (tooltip) when adding skills/injuries
* incorporate the ultimate ref sheet.
* Warband description
* Magic selection (E.g. Warrior Priest)
* Verify that exp views are disabled on Animal etc.
* Make a seperate user control for 'carried' equipment view
* The 'Tooltip' on Characteristic Sv is not updated correctly (E.g. buy Light Armour = Shield, change to Heavy Armor )

Version 2.0
* Add 'Clt+S' and 'Ctrl+Z' functions
* Progress in game (Out of action etc)
* Post Battle injuries, trading, leveling etc.
* Dramatic Personages
* Official and Unofficial warbands
* Underdog bonus.
* Share roster (via WCF) for live tracking during play

Version X.0
Random Happenings
Apply dark style to the Views, Font styles


Lesson learned during development:
- Never ever declare a UI (Windows) component if it is not directly shown (E.g. Show a user control in a Window on a Execute). Instead initiate and use in when needed;
- OO and 'clean Code' principles do not (always) apply in UI (mvvm). E.g. 2 almost identical views (thus duplicate code) are allowed in views (preferred above inheritance)