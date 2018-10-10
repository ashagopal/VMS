import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import AddVehicle from './components/AddVehicle';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout >
                <Route exact path='/' component={Home} />
                <Route exact path='/add-vehicle/:typeid' component={AddVehicle} />
                <Route exact path='/edit-vehicle/:typeid/:id' component={AddVehicle} />
            </Layout>
        );
    }
}
