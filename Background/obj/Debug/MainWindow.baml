   M S B A M L   `   `   `  ����E  ABackground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Background
Background  5   	       Background.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Background     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
Background��5	   	   $	��500��6   $	��800��6)    � Icon$ Icons/макет.png��65    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  '��       �� 5      " ��6   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    �@�Cursor$
 Hand��6#   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $��border��6   $��0q�6+   #��z��6V   ��6?   Z� ._�5      �� $��Center=�6+   $��Center=�6H   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  �@J�Opacity$	 0.8Q�68   5      5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5       $��* �6   �� 5!      $��70 �6   .+�5#   
    � -   5          �Name$ 	MainFrame��5#      $��0��6     � NavigationUIVisibility$ Hidden=�60   � 5$   
   $��1��6   ��5%      �� 5&       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67    �� RelativeTransform 5'      V� 5(      .~�5)      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5*       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5+       �� Angle$
 -135Q�6.    �� CenterY$	 0.5Q�6;    �� CenterX$	 0.5Q�6I   T� 5,      5-      .��5/      �  � Color$ 	#FF0BB5C9��6#    � Offset$ 0Q�65   � 50      $ 	#FF096A75��6#   $ 1Q�65   51      .+�53      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�54      �� -   5        $�� ��54      $
��Left=�6$   $��70,0,0,8q�6?   $��50��6Q    J� Opacity$	 0.5Q�55   J   $��45��6X   $��Bottom=�56      ��54   \   Z� ��55   4   Z� ��57      �� 58       �� ImageSource$ ./Icons/home.png��6%   5:      �� 5;      -   5        $
��Left=�5;      $��70,0,0,7q�64   $��60��6F   $	 0.5Q�5=   /   $��50��6=   $��Bottom=�6I   ��5;   Q   Z� ��5=      Z� ��5>      �� 5?      $ ./Icons/add.png��6%   5A      �� 5B      -   5        $
��Left=�5B   4   $��70,0,0,6q�6O   $��60��6a   $	 0.5Q�5C   /   $��58��6=   $��Bottom=�6I   ��5B   l   Z� ��5C      Z� ��5D      �� 5E      $ ./Icons/LikedImage.png��6%   5G      �� 5H      -   5        $
��Left=�5H      $��70,0,0,8q�64   $��50��6F   $	 0.5Q�5I   M   $��45��6[   $��Bottom=�5J      ��5H   Q   Z� ��5I   7   Z� ��5K      �� 5L      $ ./Icons/mypage.png��6%   5N      5O      5P      5Q      5R      