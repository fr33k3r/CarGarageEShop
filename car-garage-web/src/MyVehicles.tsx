import * as React from "react";
import './MyVehicles.css';
import VehicleRow from "./VehicleRow";

export interface IState { 
    loading: boolean;
    vehicles: IVehicle[];
}

export interface ILocation {
    lat: string;
    long: string;
}

export interface IVehicle {
    Id: number,
    WareHouseName: string,
    WareHouseLocation: ILocation,
    CarsLocation: string,
    Make: string,
    Model: string,
    YearModel: number,
    Price: number,
    Licensed: boolean,
    DateAdded: Date
}



export default class MyVehicles extends React.Component<any, IState>
{   

    public state: IState = { 
        loading: false,
        "vehicles" : []
    }

    public async componentDidMount() {
        this.setState({ loading: true }); // toggle on
        const result = await fetch('https://localhost:7072/api/Warehouses', 
        {
            method: 'GET',
            headers:{
              Accept: 'application/json',
                       'Content-Type': 'application/json',
                       'Authorization': "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0ZXN0U3ViamVjdCIsIk5hbWUiOiJHZW9yZ2UiLCJlbWFpbCI6ImZyMzNrM3JAeWFob28uY29tIiwiZXhwIjoxNjQwMTI0Njk3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDcyIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzA3MiJ9.YrVMrB3hY-SLGlZPjE8XfF4E8JrUpBduZ-iQat3M7NU"
        }});
        const vehicles = await result.json();
        this.setState({ vehicles, loading: false }); // toggle off
    }

    public render() {
        return (            
            <div>
                <h1>My Vehicles</h1>           
                {this.state.loading && <div>Loading...</div>}  {/* show this while loading data */}
                <table className="vehicle-list">
                    <thead>
                        <tr>                           
                            <th>ID</th>
                            <th>Make</th>
                            <th>Model</th>
                            <th>Year</th>
                            <th>Price</th>
                            <th>Licensed</th>
                            <th>Date Added</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.vehicles.map(vehicle => 
                        <VehicleRow key={vehicle.Id} vehicle={vehicle} />) }
                    </tbody>
                </table>
            </div>
        );
    }
}