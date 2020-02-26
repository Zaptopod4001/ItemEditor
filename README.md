# Item Editor (Unity 2018.4 / C#)

![Item Editor](/doc/item_editor.gif)

## What is it?

Item Editor shows how to use and implement various Unity Editor things:

* Create Scriptable Objects to be used as data containers (RPG items in this case, but could be anything)

* Contain Serializable classes inside Scriptable Objects

* Create Custom Editor/Inspector for a Scriptable Object

* Access Scriptable Object and its sub class data using Serialized Object and Serialized Properties

* Create Custom Editor Window to edit data class assets

* Use Editor layout scopes and various other Editor styling methods to style Custom Editor fields

* Create, read, update and delete (CRUD) Unity Asset files

* Display other class' Inspector (Editor) and Custom Inspector in Editor window view

* Allow editing diplayed item and persist changes to both Scriptable Object and its sub class


## Classes

### ItemDataEditor
This is the Editor Window for editing items. Item Window has minimum and maximum size.

### ItemDataSOEditor
Custom Editor for styling ItemDataSO Scriptable Object class.

### ItemDataSO
Disk persisted item data that wouldn't be serialized in game. Contains fields for assets like sound, sprite and mesh.

### ItemData
Data class to store item runtime data.



## Data Asset Files

![Item Data Files](/doc/item_data_files.png)

These are the demo ItemDataSO data asset files that can be edited with Item Editor.

## About
I created this item editor for myself for different personal Unity projects.

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
