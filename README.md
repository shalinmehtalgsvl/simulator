# <div align="center">LGSVL Simulator:  An Autonomous Vehicle Simulator </div>

<div align="center"> [![Github release][]][latest release] [![Release downloads][]]() </div>

#### <div align="center">[Website](https://lgsvlsimulator.com) | [Documentation](https://lgsvlsimulator.com/docs) | [Download](https://github.com/lgsvl/simulator/releases/latest)</div>

## Stay Informed

Check out our [blog](https://www.lgsvlsimulator.com/blog/) and subscribe to our [mailing list](http://eepurl.com/gpuhkb) to get the latest updates.


[Github release]: https://img.shields.io/github/release-pre/lgsvl/simulator.svg
[latest release]: https://github.com/lgsvl/simulator/releases/latest
[Release downloads]: https://img.shields.io/github/downloads/lgsvl/simulator/total.svg

## Introduction

LG Electronics America R&D Center has developed an HDRP Unity-based multi-robot simulator for autonomous vehicle developers. 
We provide an out-of-the-box solution which can meet the needs of developers wishing to focus on testing their autonomous vehicle algorithms. 
It currently has integration with TierIV's [Autoware](https://github.com/lgsvl/Autoware) and Baidu's [Apollo 5.0](https://github.com/lgsvl/apollo-5.0)
and [Apollo 3.0](https://github.com/lgsvl/apollo) platforms, can generate HD maps, and can be immediately used for testing and validation of a whole system with little need for custom integrations. 
We hope to build a collaborative community among robotics and autonomous vehicle developers by open sourcing our efforts. 

*To use the simulator with Apollo, first download the simulator binary, then follow the guide on our [Apollo 5.0 fork](https://github.com/lgsvl/apollo-5.0).*

*To use the simulator with Autoware, first download the simulator binary, then follow the guide on our [Autoware fork](https://github.com/lgsvl/Autoware).*

For Chinese-speaking users, you can also view our latest videos [here](https://space.bilibili.com/412295691) and download our simulator releases [here](https://pan.baidu.com/s/1M33ysJYZfi4vya41gmB0rw) (code: 6k91).
对于中国的用户，您也可在[哔哩哔哩](https://space.bilibili.com/412295691)上观看我们最新发布的视频，从[百度网盘](https://pan.baidu.com/s/1M33ysJYZfi4vya41gmB0rw)(提取码: 6k91)上下载使用我们的仿真器。

[![](Docs/docs/images/full_size_images/readme-frontal.png)](Docs/docs/images/readme-frontal.png)


## Getting Started

You can find complete and the most up-to-date guides on our [documentation website](https://www.lgsvlsimulator.com/docs).

Running the simulator with reasonable performance and frame rate (for perception related tasks) requires a high performance desktop. Below is the recommended system for running the simulator at high quality. We are currently working on performance improvements for a better experience. 

**Recommended system:**

- 4 GHz Quad Core CPU
- Nvidia GTX 1080, 8GB GPU memory
- Windows 10 64 Bit

The easiest way to get started with running the simulator is to download our [latest release](https://github.com/lgsvl/simulator/releases/latest) and run as a standalone executable.

For the latest functionality or if you want to modify the simulator for your own needs, you can checkout our source, open it as a project in Unity, and run inside the Unity Editor. Otherwise, you can build the Unity project into a standalone executable.

Currently, running the simulator in Windows yields better performance than running on Linux. 

### Downloading and starting simulator

1. Download the latest release of the LGSVL Simulator for your supported operating system (Windows or Linux) here: [https://github.com/lgsvl/simulator/releases/latest](https://github.com/lgsvl/simulator/releases/latest)
2. Unzip the downloaded folder and run the executable.

### Building and running from source

**NOTE**: to clone repository faster, clone only single branch:

    git clone --single-branch https://github.com/lgsvl/simulator.git

Check out our instructions for getting started with building from source [here](Docs/docs/build-instructions.md).


## Simulator Instructions

1. After starting the simulator, you should see a button to open the UI in the browser. 
2. Go to the Simulations tab and select the appropriate map and vehicle.  For a standard setup, select "BorregasAve" for map and "Jaguar2015XE (Apollo 5.0)" for vehicle. Click "Run" to begin.
3. The vehicle/robot should spawn inside the map environment that was selected. Read [here](Docs/docs/keyboard-shortcuts.md) for an explanation of all current keyboard shortcuts and controls.
4. Follow the guides on our respective [Autoware](https://github.com/lgsvl/Autoware) and [Apollo 5.0](https://github.com/lgsvl/apollo-5.0) repositories for instructions on running the platforms with the simulator.

[![](Docs/docs/images/readme-simulator.png)](Docs/docs/images/full_size_images/readme-simulator.png)

### Guide to simulator functionality

Look [here](Docs/docs/keyboard-shortcuts.md) for a guide to currently available functionality and keyboard shortcuts for using the simulator.



## Contact

Please feel free to provide feedback or ask questions by creating a Github issue. For inquiries about collaboration, please email us at [contact@lgsvlsimulator.com](mailto:contact@lgsvlsimulator.com).



## Copyright and License

Copyright (c) 2019 LG Electronics, Inc.

This software contains code licensed as described in LICENSE.
