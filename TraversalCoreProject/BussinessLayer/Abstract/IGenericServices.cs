﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGenericServices<T>

    {
        void TDelete(T t);
        void TAdd(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);

      /*  List<T> TGetByFilter(Expression<Func<T,bool>>filter);*/ //Şartlı listeme

    }
}
