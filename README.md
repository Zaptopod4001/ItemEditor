# Item Editor (Unity / C#)

![Item Editor](/doc/item_editor.gif)

## What is it?

Item editor shows how to create various Unity Editor things.

* Create Scriptable Objects to be used as data containers (RPG items in this case)

* Contain serializable classes inside Scriptable Objects

* Create custom Editor / Inspector for Scriptable Object

* Access Scriptable Object and its sub class data using Serialized Object and Serialized Properties

* Create Custom Editor Window to edit items

* How to create using scopes and use various Editor stylings to style Custom Editor fields

* Create, read, use and delete (CRUD) unity Assets

* Display other class Inspectors (Editor) and Custom Inspectors in Editor view

* Allow editing diplayed item and persist changes to both Scriptable Object and its sub class


# Classes

## ItemDataEditor
Editor Window for editing items. 

## ItemDataSOEditor
Custom editor for styling Scriptable Object.

## ItemData
Pure data class to store item data runtime. No asset references.

## ItemDataSO
Disk persisted item data that wouldn't be serialized in game.

## About
I created this item editor for myself for different personal Unity projects.


## Data files

![Item Data Files](/doc/item_data_files.png)

These are the ItemDataSO assets that can be edited with Item editor.


## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
If you have doubts about what you are looking and if you can use this material - leave now...
