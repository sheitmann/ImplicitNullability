﻿using JetBrains.Annotations;

namespace ImplicitNullability.Plugin.Tests.test.data.Integrative.AnnotationCopyingTests
{
    public class Base
    {
        public Base(string a, [NotNull] string b, [CanBeNull] string c, string d = null)
        {
        }
    }

    public class Derived{caret} : Base
    {
    }
}
