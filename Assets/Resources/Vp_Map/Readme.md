
# Vp_Map
-[Version 1.0]
This package will allow the developer to quickly create the new map system based on Ap13 design


## Authors

- David Baquero
- Juan David Gonzalez


## Documentation

The package contains all the stuff that the user needs to import the map with few clicks

### Prerequisites

The user needs to create a layer called "Map", if you want another name you have to change the layer name on all the scripts.

Once you have created the layer you have to deselect the layer from the main camera on the culling mask section, otherwise the camera will render all the map stuff


### How to use it
-2 UI: PanelMap and Header, the dev only needs to drag and drop on the scene inside a canvas

-Map_Creator class: The user needs to add this component inside a world object with the coordinates 0,0,0, the fields that the user needs to assign are the Map Image that will be the sprite of the map. 

The layer name by default is "Map" so as i said previously you need to create a layer with this name, or create a layer with other name and change this field.

Full map texture is the render texture that the map will display, this texture it´s located inside Vp_Map/Textures/FullMapTexture.

This class will create a camera and place it on the coordinates (the default ones works for VirtualBike) and set up the camera to display only the selected layer.

-Player_Cam: You need to add this component to every player, and assign the fields  for the indicator sprite that will be the ArrowMap and the layer name (By default is "Map") and assign the render texture of the field "MiniMapTexture" that is located on Vp_Map/Textures/MiniMapTexture. 
This class will create a camera on the player and a sprite for the arrow and will setup all the stuff to display the info on the minimap.

-Map_Indicator class: This class will instantiate the new map indicator, this script is already attached to the Header prefab, to make it work you need to assign all the transforms you want to have an indicator, then trouhgt code you call the Map_Indicator.instance.SetMarker(index of the array of transforms), this also contains a method called TurnOffIndicator that will hide the indicator if you want to

