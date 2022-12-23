import {
  Table,
  Thead,
  Tbody,
  Tfoot,
  Tr,
  Th,
  Td,
  TableCaption,
  TableContainer,
  Box,
  Image,
} from "@chakra-ui/react";
import InputModal from "./components/InputModal";
import Navbar from "./components/Navbar";
import { HeadProvider, Title, Link, Meta } from "react-head";
import React, { useState, useEffect } from "react";
import axiosInstance from "./service/axios";
import getDataProv from "./service/getDataProv";
import TableData from "./components/Table";
function App() {
  const [listData, setListData] = useState([]);
  const fetchDataList = async () => {
    try {
      const headers= { 'Content-Type': 'application/x-www-form-urlencoded' }
      const get = await axiosInstance.get("/api/visitor",headers);
      setListData(get.data.data);
    } catch (error) {
      console.log(error);
    }
  };
  useEffect (() => {
    fetchDataList()
  },[])

  const dataGuest = React.useMemo(() => [...listData], [listData])
  console.log(dataGuest);
  const columnFunction = () => [
    {
      Header : "Nama",
      accessor : "nama",
    },
    {
      Header : "No.HP",
      accessor : "no_hp"
    },
    {
      Header : "Email",
      accessor : "email"

    },
    {
      Header : "Alamat",
      accessor : "alamat"
    },
    {
      Header : "Provinsi",
      accessor : "provinsi"
    },
    {
      Header : "Kota / Kab",
      accessor : "kota_Kabupaten"
    },
    {
      Header : "Kecamatan",
      accessor : "kecamatan"
    },
    {
      Header : "Kelurahan",
      accessor : "kelurahan"
    },
    {
      Header : "KodePos",
      accessor : "kodePos"
    },
    {
      Header : "Kehadiran",
      accessor : "kehadiran"
    }
  ]
  const columns = React.useMemo(columnFunction,[])
  
 
 

  return (
    <div className="App">
      <HeadProvider>
        <div className="Home">
          <Title>Guest Book</Title>
          <Link rel="canonical" href="http://jeremygayed.com/" />
          <Meta name="example" content="whatever" />
        </div>
      </HeadProvider>{" "}
      <Navbar />
      <InputModal />
      {/* // Table */}
      <TableData columns={columns} data={dataGuest}/>
     
    </div>
  );
}

export default App;
