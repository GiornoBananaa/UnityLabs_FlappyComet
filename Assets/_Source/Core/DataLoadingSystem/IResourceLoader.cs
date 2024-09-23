﻿using System;
using Object = UnityEngine.Object;

namespace DataLoadingSystem
{
    public interface IResourceLoader
    {
        void LoadResource<T>(string path, Type key, IRepository<T> repository) where T : class;
        void UnloadResource<T>(Object asset, Type key, IRepository<T> repository) where T : class;
    }
}