import { useEffect, useState, useContext } from "react";
import FilterBox from "./FilterBox";
import  Posts  from "./Posts";
import { getPosts } from "../../../services/api-services";
import { AppContext } from "../../../context/AppContext";

const Content = () => {
  const appCtx = useContext(AppContext);
  const [posts, setPosts] = useState([]);
  

  useEffect(() => {
    console.log("SEARCH", appCtx.search);
    console.log("SORT", appCtx.sort);
    getPosts(appCtx.search, appCtx.sort).then((data) => {
      setPosts(data);
    });
  }, [appCtx.updatePost, appCtx.search, appCtx.sort]);



  return (
    <>
      <div className="content">
        <FilterBox />
        <Posts data={posts} />
      </div>
    </>
  );
};

export default Content;
