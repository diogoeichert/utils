#!/usr/bin/env bash

BREWFILE=~/Documents/Brewfile
CURRENT=$BREWFILE-`date +"%Y%m%d"`

echo Checking Command Line Tools installation

if ! xcode-select -p > /dev/null ; then
	xcode-select --install

	while ! xcode-select -p > /dev/null ; do
		sleep 10
	done
fi

echo Checking Homebrew installation

if ! brew -h > /dev/null ; then
	/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
fi

echo Checking requirements
brew ls --version contacts > /dev/null || brew install contacts
brew ls --version mas > /dev/null || brew install mas
brew ls --version node > /dev/null || brew install node

echo Checking git configuration
git config user.email > /dev/null || git config --global user.email "`contacts -Hm -f '%e'`"
git config user.name > /dev/null || git config --global user.name "`contacts -Hm -f '%n'`"

if [ -f $BREWFILE ] ; then
	echo Installing bundle from $BREWFILE
	brew bundle install --file=$BREWFILE --mas
fi

brew bundle dump --file=$CURRENT --force > /dev/null &&
echo Saved current bundle to $CURRENT
