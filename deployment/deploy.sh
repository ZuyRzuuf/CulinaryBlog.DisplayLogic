#!/bin/bash

# Source .env file
source $(dirname "$0")/.env

# Define the root directory of the solution
root_dir=$(dirname "$0")/..

# Build the entire solution
echo "Building the solution..."
dotnet build $root_dir/$SOLUTION_NAME -c $BUILD_CONFIGURATION

# Create a publish folder
echo "Publishing projects..."
mkdir -p $root_dir/publish
dotnet publish $root_dir/$SOLUTION_NAME -c $BUILD_CONFIGURATION -o $root_dir/publish --no-restore --no-build

# Remove test-related files from the publish folder
echo "Removing test-related files..."
find $root_dir/publish -type f -iname "*Test*.*" -exec rm -f {} \;
find $root_dir/publish -type d -iname "CodeCoverage" -exec rm -rf {} \;
find $root_dir/publish -type f -iname "Microsoft.CodeCoverage.*" -exec rm -f {} \;
find $root_dir/publish -type f -iname "Moq.dll" -exec rm -f {} \;
find $root_dir/publish -type f -iname "coverlet.*" -exec rm -f {} \;
find $root_dir/publish -type f -iname "xunit.*" -exec rm -f {} \;

# Check if Microsoft.VisualStudio.* files and NuGet.Frameworks.dll are necessary
# If they are not, uncomment the following lines:
# find $root_dir/publish -type f -iname "Microsoft.VisualStudio.*" -exec rm -f {} \;
# find $root_dir/publish -type f -iname "NuGet.Frameworks.dll" -exec rm -f {} \;

# Create an archive of the publish folder
echo "Creating an archive of the publish folder..."
tar -czf $ARTIFACT_NAME -C $root_dir/publish .

# Send the archive to the server
echo "Sending the archive to the server..."
rsync -avz -e "ssh" --progress $ARTIFACT_NAME $SERVER_USER@$SERVER_IP:$DESTINATION_PATH

# Unzip the artifact on the server
echo "Unzipping the artifact on the server..."
ssh $SERVER_USER@$SERVER_IP "tar -xzf $DESTINATION_PATH/$ARTIFACT_NAME -C $DESTINATION_PATH"

# Remove the zipped file from the server
echo "Removing the zipped file from the server..."
ssh $SERVER_USER@$SERVER_IP "rm $DESTINATION_PATH/$ARTIFACT_NAME"

# Cleanup
echo "Cleaning up..."
rm -rf $root_dir/publish
rm $ARTIFACT_NAME

echo "Done."

