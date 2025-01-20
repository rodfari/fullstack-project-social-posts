import {
  useCallback,
  useContext,
  useRef,
  useState,
} from "react";
import FilterBox from "./FilterBox";
import Posts from "./Posts";
import { UserContext } from "../../context/UserContext";
import { useTimeLine } from "../../hooks/useTimeLine";
import { TimelineContext } from "../../context/TimeLineContext";
import { ModalContext } from "../../context/ModalContext";
import Modal from "../shared/Modal";

const Content = () => {
  const [modal, setModal] = useState(false);

  const userCtx = useContext(UserContext);

  const { 
    posts, 
    actions, 
    hasMore, 
    params, 
    setParam, 
    forceRefresh,
    clearPosts
   } = useTimeLine();

  const toggleModal = () => {
    setModal((prev) => (prev ? false : true));
  };
  const observer = useRef();
  const lastPostElementRef = useCallback((node) => {
    if (observer.current) observer.current.disconnect();
    observer.current = new IntersectionObserver((entries) => {
      if (entries[0].isIntersecting) {
        setParam({
          type: actions.SET_PAGE,
          payload: params.page + 1,
        });
      }
    });
    if (node) observer.current.observe(node);
  }, []);

  return (
    <>
      <TimelineContext.Provider value={{ setParam }}>
        <ModalContext.Provider value={{ toggleModal }}>
          <div className="content">
            <FilterBox />
            {!posts && <p>Loading...</p>}
            {posts.length === 0 && (
              <div className="no-posts">
                <p>No posts found</p>
              </div>
            )}

            {posts.map((post) => (
              <Posts post={post} userId={userCtx.user.id} key={post.postId} forceRefresh={forceRefresh} />
            ))}
            {posts.length >= 15 && hasMore && (
              <div ref={lastPostElementRef}></div>
            )}
          </div>
          {modal && <Modal clearPosts={clearPosts} forceRefresh={ forceRefresh } />}
        </ModalContext.Provider>
      </TimelineContext.Provider>
    </>
  );
};

export default Content;
