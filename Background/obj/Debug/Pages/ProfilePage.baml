   M S B A M L   `   `   `  ����E  ABackground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Background.ModelsBackground.Models  5      "    Background.Pages.ProfilePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2modelsclr-namespace:Background.Models     5        N� Title$  ProfilePage��5      $��Stretch=�6   $��Stretch=�67    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      .R�5      � 5      5      �� 5       � ��$ Disabled=�5      5      5       N� 
Background 5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/    �� RelativeTransform 5      V� 5      .~�5      �� 	 �� CenterY$		 0.5Q�6%   
 �� CenterX$	
 0.5Q�63   �� 5       �� CenterY$	 0.5Q�6$    �� CenterX$	 0.5Q�62   �� 5       �� Angle$
 -135Q�6&    �� CenterY$	 0.5Q�63    �� CenterX$	 0.5Q�6A   T� 5      5      .��5       �  � Color$ 	#FF0BB5C9��6    � Offset$ 0Q�6-   � 5!      $ 	#FF096A75��6   $ 1Q�6-   5"       � DataContext 5$         Background.Models.Post  5%   
   .��5'      �  � RowDefinitions 5(   
   �� 5)      $	��200 �6   �� 5*      .+�5,   
   � $��0��6   .+�5-      ��  �� Orientation$ 
Horizontal=�6   .+�5.      �� .+�5/      �� -   5         ��Name$ Avatar��5/       $	��125��60   $	��125��6=   $	��Top=�6I   $
��Left=�50       $��	60,25,0,0q�51   S    �� RadiusX$	 125��6f    �� RadiusY$	 125��52       ��53      �� 54       �� Color$ White��6.    �� Opacity$	 0.4Q�6<   ��56      �� 57      -   5        
ImageBrush��57   )   59      �� 5:      -   5         ��Name$ ReductButton��5:      $��10q�63   $ ��Редактировать��6?   6X   5;       � 5<      -   5          �Name$ RedactFrame��5<        � Source$ ../Pages/AccInfoPage.xaml?�6-   5=      5>      �� 5?   
   -   5         ��Name$ ListBoxPosts��5?      $��1��6   
������ ��65   Z� ��5@      �� 5A      .R�5B      ��  ��Name$ ListItem��6!   $��5q�63   
������ $ Vertical=�5D   !   $	��220��68   $	��250��6D   .+�5E      �� $	��150��6    $	��100��6,   $��Center=�5F       ��5E   9   ��  �� Path$ Media.ImagePath�5F       �� 5G      .+�5H      �� $ 
Horizontal=�6)   .+�5I   "   �� $��Описание��6,   �� 5J   "   ��6,   �� $ Description�5K      5L      � 5M      .+�5N      � $
��Left=�6(   $��0q�6C   $	��150��6N   .+�5O   "   �� $ Avatar��6,   $��41��6<   $��41��6H   $
��Left=�6S   $��7,7,0,7q�5P   ,   $ 41��6=   $ 41��6J   ��5Q   &   �� 5R   *   $ White��6:   $	 0.4Q�6H   ��5T   &   �� 5U   *   5W   #   �� 5X   "     ��Name$  Nickname��6,   $
��Wrap=�6>   $��	TextBlock��6R   $��7,7,0,7q�6c   $��Center=�5Y   ,   $
��Left=�6G   
���   �6b   5Z      � 5[      $��Right=�6(   $��56��6D   $��0q�6P   $	��100��6[   $��RightToLeft=�5\   (   .+�5]   "   �� $  	react_kol��6,   $��Right=�6?   $
��7,19q�6[   $
��Wrap=�5^   ,   $�� ��6@   $��Center=�6I   ! K� ZIndex$	! 999��6d   
���   �5_   ,   5`      5a      5b      5c      5e      5f      5g      