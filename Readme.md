<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication1/Form1.vb))
* [Program.cs](./CS/WindowsApplication1/Program.cs) (VB: [Program.vb](./VB/WindowsApplication1/Program.vb))
<!-- default file list end -->
# How to create the LabelControl's descendant to support selecting and copying its text


<p>There are circumstances when it's necessary to display any static information in the application. In these cases, the LabelControl or the TextEdit is used. The LabelControl has an important advantage - transparency, but it doesn't support selecting and copying its text. In turn, the TextEdit doesn't support transparency, but at the same time this editor allows an end-user to select & copy an arbitrary part of its content. </p><p>To obtain a control that will be own advantages of the TextEdit (selecting and copying of the text) and LabelControl (transparency), it's possible to inherit the LabelControl and implement the required functionality manually. This example demonstrates how this task can be accomplished.</p>

<br/>


