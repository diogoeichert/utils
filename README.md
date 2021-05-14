Setup script to be run after and before reinstalling [macOS](https://www.apple.com/macos).

# Description
This script will:
- Ensure the installation of [Homebrew](https://brew.sh/) and [Xcode Command Line Tools](https://developer.apple.com/download/more/?=xcode);
- Configure git user name and email address based on user contact card if not already set;
- Install the bundle from `~/Documents/Brewfile` if present;
- Save a new bundle file afterwards, without replacing the original one.

# Usage
Copy and paste the snippet below in the Terminal and hit Enter:
```
sh -c "$(curl -fsSL https://raw.githubusercontent.com/diogoeichert/macos-setup/main/install.sh)"
```
The file will be saved with the current date, rename it to `Brewfile` to use it as your current bundle.

## Tip
Run the script before the clean install to create Brewfile with the current snapshot. Run it again after reinstalling to reinstall the bundle.
