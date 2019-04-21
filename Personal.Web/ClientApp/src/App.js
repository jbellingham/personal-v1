import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout/Layout';
import Home from './components/Home';
import Login from "./components/Login/Login";

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/login' component={Login} />
  </Layout>
);
