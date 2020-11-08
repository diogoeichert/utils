# setup-macos
Setup script to be run after a fresh macOS install

## description
This script will:
- install the Xcode command line tools
- setup git user name and email address
- install any bundle if `Brewfile` is in the current directory

## usage
Optionally `cd` to the directory where Brewfile is stored, e.g. `~/Documents`, then copy and paste the following line in the Terminal
```
curl https://raw.githubusercontent.com/diogoeichert/setup-macos/master/install.sh | bash
```

## tip
Keep your `Brewfile` in an iCloud-synced directory, such as `~/Documents`, as this shall make your next macOS install with the aid of this script much simpler
