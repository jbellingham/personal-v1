#!/bin/bash

# set environment variables used in deploy.sh and AWS task-definition.json:
export IMAGE_NAME=personal-app
export IMAGE_VERSION=latest

export AWS_DEFAULT_REGION=ap-southeast-2
export AWS_ECS_CLUSTER_NAME=personal-app-cluster
export AWS_VIRTUAL_HOST=3.24.101.26
