#!/usr/bin/env bash

# install Xcode command line tools
if ! xcode-select -p > /dev/null ; then
	xcode-select --install

	while ! xcode-select -p > /dev/null ; do
		sleep 10
	done
fi

# install Homebrew
if ! brew -h > /dev/null ; then
	/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
fi

# install packages
brew install contacts node

# setup git
git config --global user.email "`contacts -Hm -f '%e'`"
git config --global user.name "`contacts -Hm -f '%n'`"

# install apps
brew bundle install
