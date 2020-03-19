# NASA Mars Rover Photo API: Image Downloader

This project is about downloading mars rover images using [NASA Mars Rover Photos API](https://api.nasa.gov/). API.Client (Downloader) calls the Mars Rover Photos API with a given day as input and download images of all mars camera locally.

# Projects
![Mars Rover ](/diagram.jpg)
**API.Client** : Class library - Downloader calls rover api and downloads images. This is common downloader library for different client. 

**WebClient** : Web App - Web application to preview rover images. This will bring images for given date(i.e. '2019-09-28') as query parameter.

**BatchClient** : Console App - This will download all images in batch. Batch dates are provided in 'dates.txt' file.

# Prerequisites
.NET Core 2.1

Visual Studio
