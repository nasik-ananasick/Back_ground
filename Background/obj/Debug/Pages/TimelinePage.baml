   M S B A M L   `   `   `  ����E  ABackground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Background.PagesBackground.Pages  5      #    Background.Pages.TimelinePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0pagesclr-namespace:Background.Pages     5        N� Title$  TimelinePage��5      $��Stretch=�6   $��Stretch=�68    � DataContext 5	      #   Background.Pages.TimeLinePost  5
   
    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property	 P� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      .R�5      � 5      5      �� 5       � ��$ Disabled=�5      5      �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   #��z��6Z   ��6C   Z� ._�5      �� $��Center=�6/   $��Center=�6L   5        5!      P� 5"       �@J�IsMouseOver	 . . �5#   "   ��  �@J�Opacity$	 0.8Q�6<   5$      5&      5(      5)      5*      
 N� 
Background
 5+      �� 5,   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/    �� RelativeTransform 5-      V� 5.      .~�5/      ��  �� CenterY$	 0.5Q�6%    �� CenterX$	 0.5Q�63   �� 50       �� CenterY$	 0.5Q�6$    �� CenterX$	 0.5Q�62   �� 51       �� Angle$
 -135Q�6&    �� CenterY$	 0.5Q�63    �� CenterX$	 0.5Q�6A   T� 52      53      .��55      �  � Color$ 	#FF0BB5C9��6    � Offset$ 0Q�6-   � 56      $ 	#FF096A75��6   $ 1Q�6-   57      .��5:      �  � RowDefinitions 5;   
   �� 5<      $��70 �6   �� 5=      .+�5?   
   � $��0��6   
������ .+�5@      �� -   5         ��Name$ SearchTextBox��5@      $	��600��6-   
���   �$��28(�6L   $��50��6Z   $	��Top=�5A      $��4q�6.      SearchTextBox#��[  5B   >   5C      �� 5D   
   -   5         ��Name$ ListBoxPosts��5D      $��1��6   
������ ��65   Z� ��5E      �� 5F      .R�5G      ��  ��Name$ ListItem��6!   $��5q�63   
������  �� Orientation$ Vertical=�5I   !   $	��355��68   $	��335��6D   .+�5J      �  5K      �� 5L   "   �� 5M   "   $��80 �60   .+�5O      �� $��0��6$   $	��352��61   $	��255��6=   $��Center=�5P   $   ��5O   J   ��  �� Path$
 Post�5P   $   � 5Q      $��1��6#   
������ .+�5R   "   �� $
��Left=�6-   $��0q�6H   $��80��6S   $	��150��6_   .+�5S   &   ��  ��Name$ Avatar��60   $��60��6@   $��60��6L   $
��Left=�6W    �� RadiusX$ 60��5T   0    �� RadiusY$ 60��6=   ��5U   *   �� 5V   .     �� Color$  White��6>   ! �� Opacity$	! 0.4Q�6L   ��5X   *   �� 5Y   .   " �� ImageSource" 69   �� $ AccountImage�5[   '   �� 5\   &   # ��Name$# Nickname��60   $
��Wrap=�6B   $��Center=�5]   0   $
��Left=�6K   
���   ���5\   V   �� *AccountName+5]   f   5^   #   �� 5_   "   $��Right=�6-   $ 
Horizontal=�6I   $��60��6b   $��0,0,20,0q�5`   -   .+�5a   &   �� $ ��Name$$ likE_button��6-   $��60��5b   -   $��Center=�68   
������ $��60��6l   $��0,0,5,0q�5c   -   $��Paste��5d   -   ��5a   B   Z� ��5d   =   �� $ Id�% J� CommandBindings% 5e   *   )  #System.Windows.Input.CommandBinding  5f   .   -   5        &   Command$& Paste��5f   =   6M   .��5h   *   �� ' ��Name$' 	ImageLike��60   ��5i   0   �� *	LikeImage+( �� UpdateSourceTrigger$( PropertyChanged=�5j   '   �� 5k   &   
���   �$��Center=�5m   0   $��30(�6M   $��Center=�6[   ��5k   0   �� *Likes+$( PropertyChanged=�5m   [   5n   #   5o      5p      5q      5r      5t      5u      5v      