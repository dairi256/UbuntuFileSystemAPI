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
(To be added on release.)

## API Endpoints
- `POST /api/Files/upload` - Upload a new file.
- `GET /api/Files` - List all file metadata from the database.
- `GET /api/Files/{fileName}` - Download a file.
- `DELETE /api/Files/{fileName}` - Remove file from disk and database.

### This repository is licensed under the CC0-1.0 license.
