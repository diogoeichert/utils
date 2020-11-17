# macos-setup
Setup script to be run after and before reinstalling macOS.

## Description
This script will:
- Ensure the installation of Homebrew and Xcode Command Line Tools;
- Configure git user name and email address based on user contact card if not already set;
- Install the bundle from `~/Documents/Brewfile`;
- Save a new bundle file afterwards, without replacing the original one.

## Usage
```
sh -c "$(curl -fsSL https://raw.githubusercontent.com/diogoeichert/utils/main/macos-setup/install.sh)"
```

## Tip
Run the script before the clean install to create Brewfile with the current snapshot. Run it again after reinstalling to reinstall the bundle.