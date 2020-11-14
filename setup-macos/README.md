# setup-macos
Setup script to be run after a fresh macOS install.

## Description
This script will:
- Ensure the installation of Homebrew and Xcode Command Line Tools;
- Setup git user name and email address correctly;
- Install the bundle from `~/Documents/Brewfile`;
- Update the bundle afterwards.

## Usage
```
curl https://raw.githubusercontent.com/diogoeichert/utils/main/setup-macos/update.sh | bash
```

## Tip
Run the script before the clean install to update the bundle.
