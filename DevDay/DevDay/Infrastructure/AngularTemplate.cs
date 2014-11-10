﻿using System;
using System.Web.Mvc;

namespace DevDay.Infrastructure
{
    public class AngularTemplate : IDisposable
    {
        private readonly ViewContext _viewContext;
        private bool _disposed;

        public AngularTemplate(ViewContext viewContext)
        {
            _viewContext = viewContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            _disposed = disposing;
            _viewContext.Writer.Write("</script>");
        }
    }
}