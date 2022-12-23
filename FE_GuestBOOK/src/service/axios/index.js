import axios from "axios";

const axiosInstance = axios.create({ baseURL: "https://localhost:44354" });

export default axiosInstance;
