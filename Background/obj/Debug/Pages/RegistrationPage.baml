   M S B A M L   `   `   `  ����E  ABackground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Background.PagesBackground.Pages  5      '    !Background.Pages.RegistrationPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Background.Pages     5        N� Title$  RegistrationPage��5      $��Stretch=�6    $��Stretch=�6<    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  '��       �� 5
   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   #��z��6Z   ��6C   Z� ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5      � .+�5   
   �� $��Center=�6   $	��200��61   $��Center=�6>   $	��290��6Y   
�������	 J� Opacity$		 0.5Q�5   !   
 �� RadiusX$
 15��6/    �� RadiusY$ 17��6<   �� 5    
   $��Center=�6   $	��178��61   $��Center=�6>   $	��270��6Y   
�������$
 11��5!   !   $ 12��6.   �� 5"   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6G   .+�5#      �� $��Регистрация��6   $��Center=�6,   $��16(�6J   
���iii�6X   �� 5$      $ 
Horizontal=�6   .+�5%      �� $
��Left=�6   $��43,5,0,0q�67   $
��Wrap=�6I   $��Логин :��6]   $	��Top=�5&      $��16(�64   
���iii�6B   �� 5'      -   5         ��Name$ Email��5'      $
��Left=�6)   $��5q�6D   $��20��6O    �� TextWrapping$
 Wrap=�6[   $	��Top=�5(      $	��130��62   $��0,0,0,1q�6>   
���iii�
���iii�$��16(�5)   F   ��60   Z� 6F   5*      �� 5+      $ 
Horizontal=�6   .+�5,      �� $
��Left=�6   $��33,5,0,0q�67   $
��Wrap=�6I   $��Пароль :��6]   $	��Top=�5-      $��16(�64   
���iii�6B   G� 5.      -   5         G�Name$ Password��5.      $
��Left=�60   $��5q�6K   $	��Top=�6V   $	��130��5/      
���iii�
���iii� G� SelectionBrush
 �iii�$��0,0,0,1q�50   7   $��16(�6Q   $��20��6_   ��5/   *   Z� 50   _   51      �� 52      $ 
Horizontal=�6   .+�53      �� $
��Left=�6   $
��Wrap=�68   $)��#Подтвердите пароль��6L   $	��Top=�54      $��16(�64   
���iii�$��96��55   1    �� TextAlignment$ Right=�6<   G� 56      -   5        $ ConfirmPassword��56      $
��Left=�67   $��5q�6R   $	��Top=�57      $	��130��66   
���iii�
���iii�
 �iii�$��0,0,0,1q�58   L   $��16(�59      $��20��6,   ��57   B   Z� 59   ,   5:      � 5;      .+�5<      �� -   5        $
��Left=�5<      $��5q�64   $	��Top=�6?   $��35��6W   $��35��5=      ��6%   Z� ��6<   Z� ��5>      �� 5?       �� ImageSource$ ../Icons/back.png��6%   5A      �� 5B      -   5        $��Right=�5B      $��5q�66   $	��Top=�6A   $��40��6Y   $��36��5C       J� RenderTransformOrigin$ 1.726,0.547&�6%   ��6I   Z� ��6`   Z� ��5E      �� 5F      $ ../Icons/button.png��6%   5H      5I      5J      5L      5M      