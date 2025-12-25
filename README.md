# UbuntuFileSystemAPI ![Static Badge](https://img.shields.io/badge/Ubuntu%20Server-%23E95420?logo=ubuntu&labelColor=black)
A cross-management File System API, optimised for deployment on Ubuntu Server

## Features
- **Metadata Tracking:** SQLite is used to store original filenames, the size (in bytes) and upload date. SQLite is also a very lightweight database, making it usuable with a wide range of Ubuntu Servers.
- **GUID Renaming:** This helps to prevent collisions to do with filenames by storing files with a unique identifier.
- **Cross-Platform:** Configurable storage paths for Windows Development or/and Ubuntu.
## Planned Features
- **Linux Commands:** For example, typing a linux command will download the file on the server.
- **Console UI:** A clean console interface for easier access.

## Installation and Setup
1. **Download the linux .zip:** Download the linux-64.zip and connect to your server and send it to your machine using SCP.
2. **Unzip the files:** Before you unzip, please ensure that you have:
- Installed the `unzip` utility by typing this comamnd: `sudo apt update` and `sudo apt install unzip`,
- Please unzip the file in another folder, use `mkdir ~/DIRECTORY_NAME` to create a new folder,
- Then, you can use this command to unzip all contents: `unzip .zip_NAME -d ~/DIRECTORY_NAME`.
3. **Enter the directory:** In the directory, enter this command to ensure that the 'UbuntuFileSystemAPI' file is allowed to be run: `chmod +x UbuntuFileSystemAPI`/.
4.**Setup the storage folder:** These two commands create the folder in which files will be stored and your user has permission to use it:
- `sudo mkdir -p /var/www/uploads`
- `sudo chown -R $USER:$USER /var/www/uploads`
5. **Start the file:** To finally run the file, please use this command:
- `FileStorage__StoragePath=/var/www/uploads ConnectionStrings__DefaultConnection="Data Source=cloudstorage.db" ./UbuntuFileSystemAPI --urls "http://0.0.0.0:5000"`

**You can now open up a browser on your PC and head to `http://ipaddress:5000/swagger`**

## API Endpoints
- `POST /api/Files/upload` - Upload a new file.
- `GET /api/Files` - List all file metadata from the database.
- `GET /api/Files/{fileName}` - Download a file.
- `DELETE /api/Files/{fileName}` - Remove file from disk and database.

### This repository is licensed under the CC0-1.0 license.
