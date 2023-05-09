#!/bin/bash

# Set variables
solution_name="DisplayLogic.sln"
build_configuration="Release"
artifact_name="DisplayLogic_artifact.tar.gz"
server_user="zuyrzuuf"
server_ip="192.168.15.107"
destination_path="/home/zuyrzuuf/webserver/culinary-blog/display-logic"

# Build the entire solution
echo "Building the solution..."
dotnet build ./$solution_name -c $build_configuration

# Create a publish folder
echo "Publishing projects..."
mkdir -p publish
dotnet publish ./$solution_name -c $build_configuration -o ./publish --no-restore --no-build

# Remove test-related files from the publish folder
echo "Removing test-related files..."
find ./publish -type f -iname "*Test*.*" -exec rm -f {} \;
find ./publish -type d -iname "CodeCoverage" -exec rm -rf {} \;
find ./publish -type f -iname "Microsoft.CodeCoverage.*" -exec rm -f {} \;
find ./publish -type f -iname "Moq.dll" -exec rm -f {} \;
find ./publish -type f -iname "coverlet.*" -exec rm -f {} \;
find ./publish -type f -iname "xunit.*" -exec rm -f {} \;

# Check if Microsoft.VisualStudio.* files and NuGet.Frameworks.dll are necessary
# If they are not, uncomment the following lines:
# find ./publish -type f -iname "Microsoft.VisualStudio.*" -exec rm -f {} \;
# find ./publish -type f -iname "NuGet.Frameworks.dll" -exec rm -f {} \;

# Create an archive of the publish folder
echo "Creating an archive of the publish folder..."
tar -czf $artifact_name -C publish .

# Send the archive to the server
echo "Sending the archive to the server..."
rsync -avz -e "ssh" --progress $artifact_name $server_user@$server_ip:$destination_path

# Unzip the artifact on the server
echo "Unzipping the artifact on the server..."
ssh $server_user@$server_ip "tar -xzf $destination_path/$artifact_name -C $destination_path"

# Remove the zipped file from the server
echo "Removing the zipped file from the server..."
ssh $server_user@$server_ip "rm $destination_path/$artifact_name"

# Cleanup
echo "Cleaning up..."
rm -rf publish
rm $artifact_name

echo "Done."

