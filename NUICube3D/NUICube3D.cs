﻿using System;
using System.IO;
using System.Threading.Tasks;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace FirstBottomRow
{
    class Program : NUIApplication
    {
        const string resourcePath = /*Tizen.Applications.Application.Current.DirectoryInfo.Resource*/ "/home/seungho/Shared/";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;
            window.KeyEvent += OnKeyEvent;

            Layer layer = new Layer();
            layer.Behavior = Layer.LayerBehavior.Layer3D;
            window.AddLayer(layer);

            View model = new View();
            model.Size = new Vector3(600, 600, 600);
            model.PivotPoint = PivotPoint.Center;
            model.ParentOrigin = ParentOrigin.Center;
            model.PositionUsesPivotPoint = true;
            layer.Add(model);


            assembled = new ModelView(resourcePath + "assembled.obj", resourcePath + "assembled.mtl", resourcePath);
            assembled.IlluminationType = 0;
            assembled.LightPosition = new Vector3(1000, 1000, 400);
            assembled.Size = new Vector3(600, 600, 600);
            assembled.Color = new Color(0.7f, 0.9f, 0.92f, 1.0f);
            assembled.PivotPoint = PivotPoint.Center;
            assembled.ParentOrigin = ParentOrigin.Center;
            assembled.PositionUsesPivotPoint = true;
            model.Add(assembled);

            solution = new ModelView(resourcePath + "solution.obj", resourcePath + "solution.mtl", resourcePath);
            solution.IlluminationType = 0;
            solution.LightPosition = new Vector3(-500, 1000, 400);
            solution.Size = new Vector3(600, 600, 600);
            solution.Position = new Vector3(0, -100, -100);
            solution.Color = Color.Yellow;
            solution.PivotPoint = PivotPoint.Center;
            solution.ParentOrigin = ParentOrigin.Center;
            solution.PositionUsesPivotPoint = true;
            model.Add(solution);

            model.RotateBy(new Radian(new Degree(-40.0f)), new Vector3(1, 1, 1));
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        ModelView assembled;
        ModelView solution;

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}