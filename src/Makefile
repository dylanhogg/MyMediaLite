all: ../lib/mymedialite
	xbuild /p:Configuration=Debug MyMediaLite-nogui.sln
	cp -r Programs/ItemRecommendation/bin/Debug/*.dll ../lib/mymedialite
	cp -r Programs/ItemRecommendation/bin/Debug/*.exe ../lib/mymedialite
	cp -r Programs/ItemRecommendation/bin/Debug/*.mdb ../lib/mymedialite
	cp -r Programs/RatingPrediction/bin/Debug/*.mdb ../lib/mymedialite
	cp -r Programs/RatingPrediction/bin/Debug/*.exe ../lib/mymedialite

../lib/mymedialite:
	mkdir ../lib/mymedialite

clean:
	rm -f */bin/Debug/*
	rm -f */bin/Release/*
	rm -f */*/bin/Debug/*
	rm -f */*/bin/Release/*
	rm -rf */obj
	rm -rf */*/obj

${PREFIX}/lib:
	mkdir ${PREFIX}/lib

${PREFIX}/bin:
	mkdir ${PREFIX}/bin

install: uninstall ${PREFIX}/lib ${PREFIX}/bin
	mkdir ${PREFIX}/lib/mymedialite
	cp ../lib/mymedialite/* ${PREFIX}/lib/mymedialite
	cp ../bin/* ${PREFIX}/bin

uninstall:
	rm -rf ${PREFIX}/lib/mymedialite
	rm -rf ${PREFIX}/bin/item_recommendation
	rm -rf ${PREFIX}/bin/rating_prediction

