#!/bin/sh

echo "Running sample on Alpine 3.12"
docker build --no-cache --build-arg ALPINE_VERSION=3.12 .

echo "Running sample on Alpine 3.13"
docker build --no-cache --build-arg ALPINE_VERSION=3.13 .
