import { useCallback, useContext, useEffect, useRef, useState } from "react";
import FilterBox from "./FilterBox";
import Posts from "./Posts";
import { getPosts } from "../../services/api-services";
import { UserContext } from "../../context/UserContext";
import { AppContext } from "../../context/AppContext";

const Content = () => {
  const appCtx = useContext(AppContext);
  const userCtx = useContext(UserContext);

  const [posts, setPosts] = useState([]);

  useEffect(() => {
    getPosts(appCtx.page, appCtx.pageSize, appCtx.search, appCtx.sort).then(
      (data) => {
        console.log(data);
        if (data.length === 0) return;
        setPosts((prev) => {
          console.log(prev);
          if (appCtx.page < 2) return data;
          return [...prev, ...data];
        });
      }
    );
  }, [
    appCtx.updatePost,
    appCtx.page,
    appCtx.pageSize,
    appCtx.search,
    appCtx.sort,
    appCtx.repost,
  ]);

  const observer = useRef();
  const lastPostElementRef = useCallback((node) => {

    if (observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting) {
        console.log("visible");
        appCtx.setPage((prev) => prev + 1);
      }
    });
    if (node) observer.current.observe(node);
  }, []);

  return (
    <>
      <div className="content">
        <FilterBox />

        {!posts && <p>Loading...</p>}
        {posts.length === 0 && (
          <div className="no-posts">
            <p>No posts found</p>
          </div>
        )}

        {posts.map((post, index) =>
          index === posts.length - 1 && posts.length >= 15 ? (
            <Posts
              ref={lastPostElementRef}
              post={post}
              userId={userCtx.user.id}
              key={post.postId}
            />
          ) : (
            <Posts post={post} userId={userCtx.user.id} key={post.postId} />
          )
        )}
      </div>
    </>
  );
};

export default Content;
