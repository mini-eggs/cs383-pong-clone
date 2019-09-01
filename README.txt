ABOUT

This is a two player Pong clone built with the Unity editor. This document 
will guide you through setting up Unity, the repository, and building the 
game.

REQUIREMENTS

You must have Git installed. If you do not have Git installed you can find
instructions and a download link by visiting https://git-scm.com/downloads.

INSTALLING UNITY

NOTE: Unity is only officially supported on Windows and MacOS. If you use
GNU/Linux you can still install Unity but you will have to use a beta and
unofficial client (but this Pong clone was built on Arch Linux, it's possible!).

Directions for Windows/MacOS: 

1. In a web browser navigate to https://store.unity.com/download-nuo
2. Click "Start here"
3. Click "Agree and Download"
4. A file will be downloaded. Save it somewhere obvious. Your "downloads" folder
   is perfect.
5. Run the file when it has completed downloading.
6. Follow the steps that are prompted by the installation wizard. 
7. Give the installation time to complete. On completion you will be asked if
   you would like to open the Unity editor. Select no for now.


Directions for Arch Linux with Arch Linux User Repository: 

1. Open a terminal.
2. Install the Arch Linux User Repository if you have not already. Simplest way
   is by: 
   a. Installing dependencies, run `sudo pacman -S base-devel`
   b. Cloning "yay," run `git clone https://aur.archlinux.org/yay.git `
   c. Move into the recently made directory, "yay," and run `makepkg -si`
3. Install the Unity client via AUR/Yay. Run `yay -S unity-editor-lts`
4. Complete. You can now open the Unity program, called "Unity LTS."

Directions for other GNU/Linux distrobutions:

1. Open a terminal.
2. Run `wget https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.AppImage `
3. Run `chmod +x UnityHubSetup.AppImage`
4. Run `./UnityHubSetup.AppImage`
5. Follow the steps that are prompted by the installation wizard. 
6. Give the installation time to complete. On completion you will be asked if
   you would like to open the Unity editor. Select no for now.

GETTING THE CODE

1. Open a terminal.
2. Run `git clone https://github.com/mini-eggs/cs383-pong-clone `
3. Remember the directory you cloned this to. You'll need to open it in the
   Unity editor during the next step.

BUILDING THE GAME

1. Open the Unity editor.
2. On the top bar, click the "open" icon on the right.
3. Find the "cs383-pong-clone" folder you just Git cloned. Within that folder
   you will find a "pong" folder. Open that.
4. Once opened, find the "File" menu option. Select "Build and Run." Choose a
   name for the executable. I usually choose "out." This doesn't matter. Your
   choice. Click save.
5. Once opened you'll have to choose a resolution size and graphics quality. The
   default is fine. Click "ok."

HOW TO PLAY

The game is first to five wins. There are two playes, the "Left Player" and the
"Right Player." The game begins with a help screen being shown, teaching each 
player how to move their paddle. Once a game has been completed there is a 
message to show who has won. There will also be a button that says "Play 
Again!" if you wish to.

Enjoy!
