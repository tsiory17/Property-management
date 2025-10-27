import React, { useEffect, useState } from "react";
import ApartmentCard from "./ApartmentCard";

export const ApartmentGroup = () => {
  const [apartments, setApartments] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5096/api/ApartmentApi/viewApartments")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setApartments(data)
      });
  }, []);

  return (
    <div>
      <div className="container mt-4">
        <h2 className="text-center mb-4"> Apartment Listings</h2>
        <div className="row">
          {apartments.map((apt) => (
            <div key={apt.apartmentId} className="col-md-4 mb-4">
              <ApartmentCard
                numberOfRooms={apt.numberOfRooms}
                rent={apt.rent}
                status={apt.status}
                buildingAddress={apt.buildingAddress}
                city={apt.city}
                zip={apt.zip}
                apartmentImages={apt.apartmentImages}
              />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default ApartmentGroup;
