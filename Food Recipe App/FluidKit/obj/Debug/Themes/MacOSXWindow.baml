   M S B A M L   `   `   `  ����C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FluidKit.ControlsFluidKit.Controls  5
      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35   BrushedMetalBackground  �� ImageSource j� TileMode j� ViewportUnits j� Viewport  WindowBackground �� 
StartPoint �� EndPoint �� Opacity � Color � Offset  CloseButtonStyle	 �� 
TargetType#    FluidKit.Controls.ImageButton
 �� Property �� Value  MinimizeButtonStyle  MaximizeButtonStyle  GlassWindow_Template �� 
TargetType#   FluidKit.Controls.GlassWindow �Name �� CornerRadius � ColumnDefinitions � RowDefinitions � Title ��Name �� Orientation   Name ��Name F�Name � Cursor �� Stretch ��Name  MacOSXWindowStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5	      ,Controlsclr-namespace:FluidKit.Controls  5
      %�  &	        &	 s     &	 �    &	 �    &	 �    &	 �    7   7  7  7  7  &	 /    7  �� 5      $  images/metal.jpg��5      $
 Tile=�5      $ Absolute=�5      $ 	0,0,64,64�5      �� 5      $ 0,0.5&�5      $ 1,0.5&�5      $
 0.35Q�5      .��5      � $
 Gray��6   $ 0Q�5   
   � 5      $ 	Gainsboro��6   $
 0.35Q�5   
   � 5      $ 	Gainsboro��6   $
 0.75Q�5   
   � 5      $
 Gray��6   $ 1Q�5   
   5      �� 5&      "	   5'      .�5(      �� 
 �@  NormalImage$ images/osx_close.png��5)      �� 5*      
 �@  
HoverImage$" images/osx_close_hovered.png��5+      �� 5,      
 �@  PressedImage$" images/osx_close_pressed.png��5-      5.      �� 55      "	   56      .�57      �� 
 �@  NormalImage$ images/osx_min.png��58      �� 59      
 �@  
HoverImage$  images/osx_min_hovered.png��5:      �� 5;      
 �@  PressedImage$  images/osx_min_pressed.png��5<      5=      �� 5D      "	   5E      .�5F      �� 
 �@  NormalImage$ images/osx_max.png��5G      �� 5H      
 �@  
HoverImage$  images/osx_max_hovered.png��5I      �� 5J      
 �@  PressedImage$  images/osx_max_pressed.png��5K      5L      �� 5S      "  5T      .R�5U      � $ PART_WindowContainer��6	   .+�5V      �� $��0,0,0,0q�6   
�������$ 5,5,5,5��5X      $��1,1,1,1q�5Y      8��  ._�5[      �� $��0,0,0,0q�6   $ 8,8,0,0��5\   	   8�� ._�5_      � $ ContentGrid��6   $��5,5,5,5q�5`   	    5a      �� 5b   	    5d      �� 5e   	   $��20 �6   �� 5f   	   $��* �6   .+�5i      � $ PART_TitleBar��5k   
   $
��Auto��5i      $
��Auto��5j   
   
������ $��0��5m   
    5n   	   �� 5o   
   $
��Auto �6   �� 5p   
   $��* �6    5r   	   �� 5s   
   .+�5w   	   �� $��Center=�6   $	��Top=�5x      $
��Auto��5y      $��0��5z      $��2��5{      #��z 5|      #��Z��5}      #��Z��5~      #��Z��5      �� 5�   	   $ 
StackPanel��5�      $
��Left=�5�      $	��Top=�5�      $��0,0,0,0q�5�      $��16��5�      $ 
Horizontal=�5�      .+�5�   
      $ PART_CloseButton��6   8�� $��0,0,5,0q�5�         5�   
   $ PART_MinimizeButton��6   8�� $��0,0,5,0q�5�         5�   
   $ PART_MaximizeButton��6   8�� $��0,0,5,0q�5�      5�   
   5�   	   �� 5�      }�. $��1��5�      $��0,0,0,0q�5�      .u�5�   	   �� $ ContentPresenter��6   #��z��5�      #��z��5�      $
��Auto��5�      $
��Auto��5�      5�   	   5�      5�      5�      � 5�      $ ResizerGrid��5�      $��Stretch=�5�   
   $��0,0,0,0q�5�      $
��Auto��5�       5�      �� 5�       5�      �� 5�      .+�5�      F� $ PART_WResizer��5�      $��2��5�      
������ $
��Left=�5�      $��Stretch=�5�      $ SizeWE��5�      $
 Fill=�5�      ���� -1��/� -10k~	5�      F� 5�      $ PART_EResizer��5�      $��2��5�      
������ $��Right=�5�      $��Stretch=�5�      $ SizeWE��5�      $
 Fill=�5�      ���� -1��/� -10k~	5�      F� 5�      $ PART_SResizer��5�      $��2��5�      
������ $��Stretch=�5�      $��Bottom=�5�      $ SizeNS��5�      $
 Fill=�5�      ���ЀA  ��
�&r ��
	5�      F� 5�      $ PART_NResizer��5�      $��2��5�      
������ $��Stretch=�5�      $	��Top=�5�      $ SizeNS��5�      $
 Fill=�5�      ���ЀA  ��
�&r ��
	5�      �� 5�      $ PART_NWResizer��5�      
������ $
��Left=�5�      $	��Top=�5�      $��5��5�      $��5��5�      $ SizeNWSE��5�      �� 5�      $ PART_NEResizer��5�      
������ $��Right=�5�      $	��Top=�5�      $��5��5�      $��5��5�      $ SizeNESW��5�      �� 5�      $ PART_SEResizer��5�      
������ $��Right=�5�      $��Bottom=�5�      $��5��5�      $��5��5�      $ SizeNWSE��5�      �� 5�      $ PART_SWResizer��5�      
������ $
��Left=�5�      $��Bottom=�5�      $��5��5�      $��5��5�      $ SizeNESW��5�      5�      5�      5�      �� 5�      "	  5�      .�5�      �� 
 �@�AllowsTransparency . 5�      �� 5�      
 �@�WindowStyle$
 None=�5�      �� 5�      
 �@�
ResizeMode$ 	CanResize=�5�      �� 5�      
 � ��8   5      5     5     