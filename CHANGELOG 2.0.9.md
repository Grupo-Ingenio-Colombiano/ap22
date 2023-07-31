# Changelog
This file will be documented this file all changes in .

## Owner
grupo Ingenio Colombiano



## [2.0.9] - 2023-31-07

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]
[Diego salamanca / dsalamanca@ingeniocolombiano.com]

### Fixed
-[TimeCounter] New logic for get time, set time from system.date.now instead update method and time.time
## [2.0.8] - 2023-27-07

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]
[Diego salamanca / dsalamanca@ingeniocolombiano.com]

### Added
-[UI] Add blue indicator to character selection scene
-[Functionality] Now calculation fields works with colombian culture info and replace dot (.) to coma (,) in Sampling and Historical Quests

### Changed
-[Functionality] Fixed hours to minutes in sampling quest calculation



## [2.0.7] - 2023-30-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]
[Diego salamanca / dsalamanca@ingeniocolombiano.com]

### Fixed
-[Data] Fixed data on excel ields toogle "cumple la demanda"
-[Data] Fixed data on excel fields "Unidades producidas"
-[Calculate] Fixed historical data random generation for prevend more than one modal


## [2.0.6] - 2023-29-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]
[Diego salamanca / dsalamanca@ingeniocolombiano.com]

### Added

-[Excel] Add new fields for correct answers comparation 

### Fixed
-[UI] Fixed ortographic errors on help panel 

## [2.0.5] - 2023-17-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]
[Diego salamanca / dsalamanca@ingeniocolombiano.com]

### Added

-[functionality] Now if you don´t talk with security guard in the beginning you can´t pass to other places in practice
-[functionality] Now button continue on operator turn table only appears when you click on board
-[Excel] Add new fields for new experience in historical final report, now can reach 500 
-[Excel] Add new fields for new experience in sampling final report, now can reach 500 

### Fixed

-[functionality] Fixed wrong calculation historic data on load
-[functionality] Fixed wrong calculation sampling data on load
-[functionality] Fixed virtualina item, now it adds to inventory on load 
-[UI] Fixed cronometer icon on sampling quest, doesn´t cover the next button dialog 
-[UI] Fixed operator talk indicator on sampling quest in index 3, appears near to the head of operator NPC
-[UI] Fixed count indicator on sampling quest in index 3, not appears next to model, appears above 
-[UI] Fixed empty icon in inventory when virtualina be used
-[functionality] Prevent movement and toggle camera on input focus


## [2.0.4] - 2023-17-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]

### Added
-[Experience] add new experience function in historical quest, now adds experience in different game points
-[Experience] add new experience function in sampling quest, now adds experience in different game points and sampling quest now can reach 500 
-[CLue] Now the clue panel dissappears after five seconds.

### Fixed

-[UI] Fixed select turn operator UI, button continue appears 
-[UI] Fixed name fromm security guard in dialog, now is "Vigilante"
-[Settings] Sound button in menu setting now mute and unmute sound

### Removed
-[Experience] removed experience function in historical quest, not add experience in prizes received 
-[Experience] removed experience function in sampling quest,  not add experience in prizes received 

## [2.0.3] - 2023-17-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]

### Added
-[functionality] wrong way alert and  count when the player walk out of correct way 
-[UI] add ingco build logo

### Fixed

-[Bug] Fixed bug menu, remove scripts for quality graphic
-[Bug] Remove player settings library for build error
-[Bug] Fix Vide foreach error, this was gererated by foreach bucle, solution: for bucle was used

### Removed
-[Api] depreaced webGl 1.0 API 



## [2.0.2] - 2023-12-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]

### Added
-[Instructions] Instructions Screen
-[Instructions] Show load and save icon in instructions

### Changed

-[UI] Fixed HUD, inventory and mini map for differents resolutions

## [2.0.1] - 2023-04-05

## Developers
[Felipe Izquierdo Arias / programadorunity02@ingeniocolombiano.com]

### Removed
-Old data package
-unused scenes of the build settings ( Old loading scene, old character selection scene and old Introduction scene)
-Old inventory system

### Added
-[Animation] DoTween Package to make animations trought code
-[UI] new Login Screen 
-[Messagge] Notice Package for displaying messages during the game
-new Data package for uploading and downloading data to the server
-new Loading Screen
-new Final report screen
-new Character Selection Scene
-Save and Load feature: The game will store all the required information on the new UserData and uploads to the server and download the data if the user acepts to on the Login Scene.
-2 CheckPoints to save the data during the game in each method.
-new Notes Panel with the User Notes menu, in this menu the user can write whatever he wants for resolve the practice
-functionality to send emails to the teacher with the final report of the student.
-change view Button, with this button the user can change between first and third person
-saving icon that appears when uploading and downloading data


### Changed
-[UnityEditor] Updated to 2021.3.24f1 LTS
-Changed the UI assets and fonts for all the windows and messages (OpenSansRegular and OpenSansBold).
-UI and fonts for the Dialogs panel.
-Most of the icons for the items.
-The talk button now is on the Center of the Screen.
-The old text assets on the project to TextMeshPro.
-The items on the inventory that doesnt have items will be disabled. 
-Updated the Pause Menu with new UI.
-Fixed bugs with the scores of the group in the RULA methodology on the PC
-Updated VIDE Editor to the lastest version
.Updated the indicators where the player has to go
-When going to the spots to take the photos, the user will automatically align itself to the photo place
-Resized "OK" or "Close buttons of all the windows (the previous dimensions was making them looking like rectangles, so they were changed to symetrical values)
-Updated Instructions Panel with new Layout and UI assets
-Fixed Missing  arrow sprites on the PC UI



## [1.0.0] - 2023-03-02
 ## Developers 
[ Diego Salamanca / diegocolmayor@gmail.com ] 

### Removed

-[Collab] version control package
### Added

### Changed

-[unity_editor] update to Unity editor 2019.4.40 lts






