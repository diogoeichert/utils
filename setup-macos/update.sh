#!/usr/bin/env bash

BREWFILE=~/Documents/Brewfile

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

echo Installing requirements
brew install contacts mas node

echo Setting up git user
git config --global user.email "`contacts -Hm -f '%e'`"
git config --global user.name "`contacts -Hm -f '%n'`"

if [ -f $BREWFILE ] ; then
	echo Installing bundle from $BREWFILE
	brew bundle install --file=$BREWFILE --mas
fi

echo Saving current bundle
brew bundle dump --describe --file=$BREWFILE-`date +"%Y%m%d"` --force
