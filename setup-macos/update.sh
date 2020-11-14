#!/usr/bin/env bash

BREWFILE=~/Library/Mobile\ Documents/com~apple~CloudDocs/Documents/Brewfile

# Check for Xcode Command Line Tools
if ! xcode-select -p > /dev/null ; then
  xcode-select --install

  while ! xcode-select -p > /dev/null ; do
    sleep 10
  done
fi

# Check for Homebrew
if ! brew -h > /dev/null ; then
  /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
fi

# Use taps
brew tap homebrew/bundle
brew tap homebrew/cask
brew tap homebrew/cask-fonts
brew tap homebrew/core
brew tap homebrew/services
brew tap mas-cli/tap

# Install required packages
brew install contacts mas node

# Setup git
git config --global user.email "`contacts -Hm -f '%e'`"
git config --global user.name "`contacts -Hm -f '%n'`"

# Install apps
brew bundle install --file=$BREWFILE

# Update bundle
brew bundle dump --describe --file=$BREWFILE --force
