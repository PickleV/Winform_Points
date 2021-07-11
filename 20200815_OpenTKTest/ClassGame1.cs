using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace _20200815_OpenTKTest
{
    class ClassGame1:GameWindow
    {
        //Constructor Accept dimension
        public ClassGame1(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) {  }

        //Init.运行一次
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Gray); //两帧之间的颜色，如果被清除后，类似背景色
            //Code goes here
            base.OnLoad(e); //运行父类中的程序
        }

        //渲染
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //每次Render前，都要Clear一次,使用 GL.ClearColor(Color.Gray);中的颜色。
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //Code goes here.
            Context.SwapBuffers();//double-buffered, 一帧显示，一帧Render,交换这两帧
            base.OnRenderFrame(e);
        }


        //显示新的帧
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //Get the state of the keyboard this frame
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

    }
}
