# Item Editor (Unity / C#)

![Item Editor](/doc/item_editor.gif)

## What is it?

Item Editor shows how to use and implement various Unity Editor things:

* How to create Scriptable Objects to be used as data containers (RPG items in this case, but could be anything)

* How to Contain Serializable classes inside Scriptable Objects

* Create Custom Editor/Inspector for a Scriptable Object

* Access Scriptable Object and its sub class data using Serialized Object and Serialized Properties

* Create Custom Editor Window to edit data classes

* Create editor layout scopes and use various other Editor styling methods to style Custom Editor fields

* Create, read, use and delete (CRUD) Unity Asset files

* Display other class' Inspector (Editor) and Custom Inspector in Editor window view

* How to allow editing diplayed item and persist changes to both Scriptable Object and its sub class


# Classes

## ItemDataEditor
This is the Editor Window for editing items. Item Window has minimum and maximum size.

## ItemDataSOEditor
Custom editor for styling Scriptable Object.

## ItemData
Data class to store item data runtime. No asset references.

## ItemDataSO
Disk persisted item data that wouldn't be serialized in game. Contains fields for assets like sounds, sprites and meshes.

## About
I created this item editor for myself for different personal Unity projects.


# Data files

![Item Data Files](/doc/item_data_files.png)

These are the demo ItemDataSO data file assets that can be edited with Item Editor.


## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
